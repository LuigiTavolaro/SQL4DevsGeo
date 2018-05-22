CREATE TABLE #SpatialTable   
    ( id int IDENTITY (1,1),  
    GeomCol1 geometry,   
    GeomCol2 AS GeomCol1.STAsText() );  
GO  
ALTER TABLE #SpatialTable   
ADD CONSTRAINT enforce_location_srid4199
CHECK (GeomCol1.STSrid = 4199); 
