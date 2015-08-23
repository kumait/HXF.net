# **HXF.net**

_Simplicity is a prerequisite for reliability_  
 _Edsger W. Dijkstra_

* * *

**HXF** stands for _High productivity Cross-Platform Framework_. The idea behind HXF is to create a framework that boosts developer's productivity while persevering efficiency and performance features. The whole framework tries to implement advanced features while preserving simplicity and efficiency at the same time.  

HXF, at this stage, covers two main areas which are **persistence** and **web services**, they are covered by two sub-frameworks which are HXF-WS and HXF-P correspondingly.  

**HXF-WS** is built on top of bare HTTP as a messaging protocol and JSON as a message format, messages exchanged with the server are very compact and easy to be serialized/de-serialized. Based on this, HXF-WS is very efficient when compared to other frameworks that depend on heavier and more complex standards such as XML, SOAP and WSDL.

**HXF-P** is based on the idea of using stored procedures as a single communication point to the underlying database, such solution makes it easy to generate code that translates each stored procedure into a method. A stored procedure is much like a method or function which makes it easy to represent it in the business logic layer. ORM (Object relational mapping such as JPA and Entity Framework) tools depend on a different idea where tables are represented as classes with extra metadata added to them by using programming languages specific features (C# attributes, Java annotations) or configuration files, such solution makes the ORM tool a complex system that adds more complexity to the developed solution. Furthermore, ORM tools depend on runtime SQL generation in order to communicate with the underplaying database, generating correct and efficient SQL code at runtime for several relational databases and several SQL dialects is a challenging problem that makes the mapping tool suffer from complexity and limited functionality.  

Simplicity does not mean that developers will sacrifice features when using HXF, on the contrary, they can create web services that have all the required features while being light-weight, efficient and easy to be maintained. It is also much easier and efficient to maintain the light-weight data access layer using HXF-P concepts.  

Portability is the second design factor that was taken into consideration. While simplicity ensures reliability, it is also easier to build portable designs when the used standards are easy to be implemented, based on this, HXF-WS web services can easily be consumed from a wide range of clients and HXF-P currently supports SQL Server and MySQL RDBMSs with the possibility to add more easily.  

For more information about HXF please refer to documentation.
