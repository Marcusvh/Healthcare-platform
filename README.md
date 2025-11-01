# Healthcare-platform

## Architecture overview
flowchart TB
  subgraph "Hospital_Network (On-Prem)"
    direction TB

    subgraph "Device_Layer"
      D1["Wearable / Bedside Devices"] -->|Bluetooth / Vendor API| GW["Device Gateway"]
      GW -->|Produce Telemetry| KAFKA["Kafka Cluster (topics: vitals, device-events)"]
    end

    subgraph "Ingestion & Event Bus"
      KAFKA --> MQPROC["Realtime Processor / Stream Consumers"]
      KAFKA --> PROJ["Projection Services (consume domain events)"]
      KAFKA --> DSS["DSS Service (consume/produce advisory events)"]
      KAFKA --> ALERT["Alerting Service (consume vitals -> generate alert events)"]
    end

    subgraph "Write_Model"
      CMDAPI["Command API (Write)"] -->|Produce Command Events| KAFKA
      CMDAPI --> WRITE_DB["Write DB (Postgres Primary)"]
      WRITE_DB --> EVENT_STORE["Optional Event Store / Event Log"]
    end

    subgraph "Read_Model"
      PROJ --> READ_DB["Read DB (Postgres Read-Optimized)"]
      PROJ --> CACHE["Redis / Materialized Views"]
      MQPROC --> INFLUX["Time-Series DB (InfluxDB)"]
      INFLUX --> DASH["Real-time Dashboards / Staff UI"]
    end

    subgraph "API Layer & Clients"
      QUERYAPI["Query API (Read)"] --> READ_DB
      QUERYAPI --> INFLUX
      WEB["Staff Web Dashboard"] <--> QUERYAPI
      PATWEB["Patient Portal (future)"] <--> QUERYAPI
      NOTIF["Notification Service (Push)"] <-- ALERT
      NOTIF --> WEB
    end

    subgraph "Analytics & BI"
      ETL["ETL / Stream Processing"] <-- KAFKA
      ETL --> BI["Power BI (On-Prem Gateway)"]
    end

    %% connections
    CMDAPI -.-> QUERYAPI[/"Command -> Query synchronization via events"/]
    KAFKA --> LOGS["Audit & Event Logs"]
  end

  classDef db fill:#8ab8d8,stroke:#036,stroke-width:1px,color:#000;
  class WRITE_DB,READ_DB,INFLUX,EVENT_STORE db;

## Event flow
flowchart LR
  A["Client (Staff UI)"] -->|"POST /patients (Command)"| CMDAPI["Command API"]
  CMDAPI -->|Validate & Handle Command| DOMAIN["Domain Model / Handlers"]
  DOMAIN -->|Persist to Write DB| WRITE_DB["Write DB (Postgres Primary)"]
  DOMAIN -->|Publish Event| KAFKA["Kafka (topic: domain-events)"]
  KAFKA -->|Consume| PROJ["Projection Service"]
  PROJ -->|Update| READ_DB["Read DB (Denormalized)"]
  READ_DB -->|Serve| QUERYAPI["Query API"]
  QUERYAPI -->|GET /patients/:id| A

  KAFKA -->|Telemetry topic| TIMESCALEDB["TimescaleDB"]
  TIMESCALEDB -->|Real-time read| DASH["Dashboard"]

  classDef db fill:#8ab8d8,stroke:#036,stroke-width:1px,color:#000;
  class WRITE_DB,READ_DB,TIMESCALEDB db;
