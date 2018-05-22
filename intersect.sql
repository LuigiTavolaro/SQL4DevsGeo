DECLARE @geom1 geometry;  
DECLARE @geom2 geometry;  
DECLARE @result geometry;  


CREATE TABLE #SpatialTable   
    ( id int IDENTITY (1,1),  
    GeomCol1 geometry,   
    GeomCol2 AS GeomCol1.STAsText() );  


INSERT INTO #SpatialTable (GeomCol1)  
VALUES (geometry::STGeomFromText('LINESTRING (100 100, 20 180, 180 180)', 0));  

INSERT INTO #SpatialTable (GeomCol1)  
VALUES (geometry::STGeomFromText('POLYGON ((0 0, 150 0, 150 150, 0 150, 0 0))', 0)); 


SELECT @geom1 = GeomCol1 FROM #SpatialTable WHERE id = 1;  
SELECT @geom2 = GeomCol1 FROM #SpatialTable WHERE id = 2;  
SELECT @result = @geom1.STIntersection(@geom2);  
SELECT @result;


drop table #SpatialTable