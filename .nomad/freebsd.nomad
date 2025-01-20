job "skistore" {
  datacenters = ["dc1"]
  type = "service"

  group "skistore-group" {
    count = 2

    task "skistore-task" {
      driver = "pot"

      config {
        pot_name = "skistore"
      }

      resources {
        cpu    = 500
        memory = 256
      }
    }
  }

  update {
    max_parallel = 1
    min_healthy_time = "10s"
    healthy_deadline = "3m"
    auto_revert = false
    canary = 1
  }

  scaling {
    enabled = true

    policy {
      type = "horizontal"

      min = 1
      max = 10

      metric = "cpu"
      target = 70
    }
  }
}
