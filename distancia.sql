DECLARE @Paris geography = geography::Point(48.87, 2.33, 4326);
DECLARE @Berlin geography = geography::Point(52.52, 13.4, 4326);
SELECT @Paris.STDistance(@Berlin); 
