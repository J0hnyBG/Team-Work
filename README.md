<p align="center">
<a href="http://academy.telerik.com/">
<img src="https://camo.githubusercontent.com/08ecbe7b67d65cc7c6990787e2836b27b4296f2d/68747470733a2f2f7261772e6769746875622e636f6d2f666c65787472792f54656c6572696b2d41636164656d792f6d61737465722f50726f6772616d6d696e6725323077697468253230432532332f436f6465732f4f746865722f54656c6572696b2e706e67"/>
</a>

<h1 align="center">CSharp Databases October 2016 - Team "Russian-Spring-Punch"</h1>

###:mortar_board:Team Members
| Name              | Academy Username      	|
|-------------------|-------------------|
|                   | :white_check_mark:|
|Александър Несторов |__Alexander.N__	        |
|Ангел Ангелов |__angel.angelov.7146557__    	|	
|Иван Първанов |__ivan.parvanov.1__ |
|Калоян Стефанов |__kaloyanchost__            	|		
|Спасимира Хаджиева|__SpasimiraHadzhieva__    	 	|	
|Станимир Стоев|__Stanimir_Stoev__       	|		

#   Databases 2016: Project Documentation

#   Car Factory Database
* A car dealership factory which holds information about its cars, models, dealers, manufacturers, dealer towns in MongoDB database consisting of 8 tables.
* See examples for the following schema for car dealership factory:

#### Cars

| Id | ModelId | DealerId | OrderId | Base Price | Year |
|----|----------|---------------------|-----------|------------|
| 1  | 2       | 1      | 100       | 25 000       | 10.10.2008
| 2  | 3       | 2 | 100       | 35 000       | 12.12.2006
| 3  | 4       | 3       | 300       | 55 000       | 09.09.2014
| 4  | 5       | 4   | 200       | 12 000       | 01.01.2007
| …  | …        | …                   | …         | …          |

#### Models

| ID |             Model Name             | Year | ManufacturerId | EngineId | PlatformId |
|----|-------------------------------------|---- | ---- | ---- | ---- |
| 1 | Nestle Sofia Corp.                  | 10.10.2008 | 1 | 5 | 0 |
| 2 | Zagorka Corp.                       | 12.12.2006 | 2 | 6 | 1 |
| 3 | Targovishte Bottling Company   Ltd. | 09.09.2014 | 3 | 6 | 2 |
| 4 | Targovishte Bottling Company   Ltd. | 01.01.2007 | 4 | 3 | 1 |
| …  | …                                   | … | … | … | … |

#### Dealer towns

| ID  | DealerTown |
|-----|--------------|
| 1 | Sofia       |
| 2 | Plovdiv       |
| 2 | Plovdiv       |
| 4 | Burgas       |
| …   | …            |
