# Healthcare-platform

flowchart TB
    subgraph Hospital_Network["🏥 On-Prem Hospital Network"]
        subgraph Device_Layer["Device Layer"]
            A1[Wearable / Bedside Devices] -->|Bluetooth / Vendor API| GW[Device Gateway]
        end

        subgraph Data_Ingestion["Data Ingestion"]
            GW --> MQ[Message Broker (RabbitMQ)]
            MQ --> RTDB[Time-Series DB (InfluxDB)]
            MQ --> ALRT[Alerting Service]
            MQ --> API
        end

        subgraph Application_Layer["Application Layer"]
            API[HealthcareSystem.API (ASP.NET Core)]
            API --> APP[Application Layer]
            APP --> INFRA[Infrastructure (EF Core / Repos)]
            APP --> DSS[Decision Support System]
            APP --> NOTIF[Notification Service]
            APP --> PSQL[(PostgreSQL Database)]
            APP --> RTDB
            DSS --> PSQL
            ALRT --> NOTIF
        end

        subgraph Client_Layer["Client Interfaces"]
            WEB[Staff Web Dashboard]
            PATWEB[Patient Portal (future)]
            WEB <--> API
            PATWEB <--> API
            NOTIF --> WEB
        end

        subgraph Analytics["Reporting & BI"]
            BI[Power BI On-Prem]
            BI <-->|On-Prem Data Gateway| PSQL
            BI <-->|ETL/Analytics| RTDB
        end
    end

    classDef db fill:#cdeaff,stroke:#036,stroke-width:1px;
    class PSQL,RTDB db;
