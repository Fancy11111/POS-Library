# Display coordinates
This project displays Point (in Map Coordinates) on a Map (Canvas).

## Latitude & Longitude
Latitude is the position on the y-Axis (horizontal)
Longitude is the position on the x-Axis (vertical)

## Calc the location
LatMax, LatMin, LngMax, LngMin := Boundaries of the displayed map


LatRange := LatMax - LatMin

LngRange := LngMax - LngMin

### Y-Value of Point

(pointY - LatMin) / CanvasHeight == pointLat / LatRange  

#### Top of Canvas === LatMin

pointY = pointLat / LatRange * CanvasHeight

#### Top of Canvas === LatMax

pointY = (CanvasHeigt - pointLat) / LatRange * CanvasHeight

### X-Value of Point

pointX / CanvasWidth == pointLng / LngRange  

pointX = (pointLng - LngMin) / LngRange * CanvasWidth

