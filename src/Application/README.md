## Application Layer

The application layer is structured to efficiently handle the application's use cases.

### Common

The `Common` directory contains interfaces and abstract classes that reinforce the system's architectural foundation. Additionally, interfaces pertaining to the infrastructure are initially defined here and subsequently implemented in the Infrastructure layer.
### Features

Application features are organized based on the entities they pertain to. To further refine this structure, the Command Query Responsibility Segregation (CQRS) approach is adopted, segregating functionalities into 'Commands' and 'Queries' folders.

**CQRS Overview**: CQRS is a pattern that separates the read actions (queries) from the write actions (commands) to optimize scalability, maintainability, and security. By employing CQRS, systems can effectively isolate the logic and scalability concerns between the two operations.

The prevalent Mediator pattern is integrated to ensure compliance with the CQRS paradigm, streamlining command and query operations and facilitating easier intercommunication within the application components.
