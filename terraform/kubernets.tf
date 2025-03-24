resource "kubernetes_deployment" "api" {
  metadata {
    name = "api-deployment"
    labels = {
      app = "api-pod"
    }
  }

  spec {
    replicas = 2

    selector {
      match_labels = {
        app = "api-pod"
      }
    }

    template {
      metadata {
        labels = {
          app = "api-pod"
        }
      }

      spec {
        init_container {
          name  = "ef-database-update"
          image = "mcr.microsoft.com/dotnet/sdk:8.0"  # Usando a imagem do SDK do .NET
          #command = [
           # "sh", "-c",
            #"dotnet ef database update --project /app/src/Infrastructure/Infra.Data/FoodOrder.Data.csproj --startup-project /app/src/Presentation/API/FoodOrder.API.csproj"
          #]
          env {
            name = "ConnectionStrings__DefaultConnection"
            value = "Host=food-order-db.cpqtqlmpyljc.us-east-1.rds.amazonaws.com;Port=5432;Database=foodorderdb;Username=postgres;Password=postgres"
          }
        }

        container {
          name  = "api-pod-config"
          image = "vilacaro/api:v4.1"

          port {
            container_port = 9000
          }

          env {
            name  = "ASPNETCORE_URLS"
            value = "http://0.0.0.0:9000"
          }

          env {
            name = "ConnectionStrings__DefaultConnection"
            value = "Host=food-order-db.cpqtqlmpyljc.us-east-1.rds.amazonaws.com;Port=5432;Database=foodorderdb;Username=postgres;Password=postgres"
          }
        }
      }
    }
  }
}

resource "kubernetes_service" "api" {
  metadata {
    name = "api-svc"
    labels = {
      app = "api-svc"
    }
  }

  spec {
    selector = {
      app = "api-pod"
    }

    port {
      port        = 80
      target_port = 9000
      node_port   = 30080
    }

    type = "LoadBalancer"
  }

  depends_on = [
    kubernetes_deployment.api
  ]
}

# ConfigMap para as configurações do banco de dados
resource "kubernetes_config_map" "db_config" {
  metadata {
    name = "db-config"
  }

  data = {
    DB_CONNECTION_STRING = "Host=food-order-db.cpqtqlmpyljc.us-east-1.rds.amazonaws.com;Port=5432;Database=foodorderdb;Username=postgres;Password=postgres"
  }
}

resource "kubernetes_job" "ef_database_update" {
  metadata {
    name = "ef-database-update"
  }

  spec {
    template {
      metadata {
        labels = {
          app = "ef-database-update"
        }
      }

      spec {
        container {
          name  = "ef-database-update"
          image = "mcr.microsoft.com/dotnet/sdk:8.0"  # Usando a imagem do SDK do .NET

          command = [
            "sh", "-c",
            "dotnet tool install --global dotnet-ef && dotnet ef database update --project /app/src/Infrastructure/Infra.Data/FoodOrder.Data.csproj --startup-project /app/src/Presentation/API/FoodOrder.API.csproj"
          ]

          # Adiciona o diretório de ferramentas ao PATH
          env {
            name  = "PATH"
            value = "/root/.dotnet/tools:/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin"
          }

          env {
            name = "ConnectionStrings__DefaultConnection"
            value_from {
              config_map_key_ref {
                name = "db-config"
                key  = "DB_CONNECTION_STRING"
              }
            }
          }
        }

        restart_policy = "Never"  # Não reiniciar o pod após a execução
      }
    }
  }
}
