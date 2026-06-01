# 🛒 ECommerce Microservices Ecosystem

A modern, production-grade distributed E-Commerce system built using **.NET Aspire**, decoupled via **Apache Kafka**, and structured under an **Event-Driven Microservices Architecture**.

---

## 🏗️ Architecture Blueprint

The ecosystem is designed to mimic real-world enterprise infrastructure, minimizing tight service coupling and preventing synchronous database locking:

1. **Frontend Layer (`ECommerce.Web`):** A responsive interactive UI built with **Blazor Web Components** and styled beautifully with modern Bootstrap utility layouts.
2. **Asynchronous Orchestration Engine (`ECommerce.AppHost`):** Leverages **.NET Aspire** to automate container management, service discovery, cloud configuration variables, and distributed OpenTelemetry logging dashboards.
3. **Event Streaming Broker (`Apache Kafka`):** Manages reliable real-time messaging pipes between completely isolated domain environments.
4. **Decoupled Persistent Services:**
   * **`OrderService` (Ordering Bounded Context):** Absorbs shopping checkouts, writes transaction entities, and broadcasts transaction events downstream via Kafka.
   * **`ProductService` (Inventory Bounded Context):** Houses stock-keeping records and features a non-blocking Background Broker Worker continuously optimizing safe inventory updates.

---

## 📂 Complete System Visual Tree

```text
ECommerce.Web/ (Solution Root)
│
├── 🚀 ECommerce.AppHost/         # .NET Aspire Orchestrator Project
│   └── kafka.yml                 # Docker infrastructure script (Kafka & ZooKeeper)
│
├── 📦 ECommerce.OrderService/    # Ingests user orders & publishes checkout events
│   ├── Controllers/              # API Web Endpoints
│   └── Data/                     # Order domain independent database records
│
├── ⚡ ECommerce.ProductService/  # Houses catalog states & inventory thresholds
│   ├── Kafka/
│   │   └── KafkaConsumer.cs      # Resilient background long-polling worker thread
│   └── Data/                     # Product catalog independent database records
│
├── 🔄 ECommerce.Shared/           # Cross-boundary DTOs, Contracts & Base Models
│
└── 💻 ECommerce.Web/              # Blazor Web frontend application client UI
    ├── Components/               # User-Interface presentation layers
    └── Utils/                    # Network clients & utility extensions
