# myApplicationBack
Como estrategia de despliegue de esta aplicación. se contemplaron repositorios, analizadores de código y flujos de pipelines:

- **Control de versiones:** Utiliza un sistema de control de versiones (como Git) para mantener un historial
de todas las versiones de la aplicación, incluidos todos los cambios realizados en el código fuente, 
implementando una estrategia de gitflow, como repositorio de código manejaremos gitHub a continuación
tenemos in link que nos ayudara a comprender que se pretende con el uso de gitflow.

(https://www.atlassian.com/es/git/tutorials/comparing-workflows/gitflow-workflow.)

- **Análisis de código:** Utilizaremos un análisis de código estático (como SonarQube) para analizar el código fuente
de la aplicación en busca de problemas potenciales de calidad del código, vulnerabilidades de seguridad,
entre otros. Las herramientas de análisis de código se integran en los flujos de trabajo de los pipelines,
con la creación de PR se desencadena el flujo de análisis de código buscando lo anteriormente mencionado.
Se define una cobertura de código del 80% en test unitarios.  

- **Integración continua:** Cuando se realizan cambios en el código fuente en el repositorio de Git de desarrollo,
se ejecuta un flujo de pipeline de integración continua para compilar, probar y empaquetar la aplicación.
El pipeline puede incluir pruebas de unidad, pruebas de integración y otros tipos de pruebas automatizadas
para garantizar que la aplicación funcione correctamente.
Como herramientas para cumplir este proceso podemos utilizar, GitHub Actions o cualquier herramienta open-source como:
CircleCI, Travis CI, Jenkins.

- **Cloud:** en este proceso se plantea hacer uso de los servicios de AWS serverless o administrados como instancias EC2,
la creación de estos recursos se realizará por medio de los flujos pipelines utilizando platillas YAML.
Utilizando estrategias de infraestructura como código (IaC) que son un enfoque para la administración de 
infraestructuras de TI que se basa en la automatización y la gestión del ciclo de vida de la infraestructura mediante código, 
mejorando el tiempo de despliegues entre los diferentes ambientes.

- **Despliegue en producción:** Cuando la aplicación ha pasado todas las pruebas y se ha aprobado el despliegue,
se ejecuta un flujo de pipeline de entrega continua o implementación continua para desplegar la aplicación
en el entorno de producción.
Esto puede implicar la configuración de servidores y otros recursos necesarios para la aplicación.
