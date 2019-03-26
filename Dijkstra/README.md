# [Dijkstra's Algorithm](https://en.wikipedia.org/wiki/Dijkstra's_algorithm)

## Setup
1. Mark all nodes unvisited (visited = false)
2. set distance of all Nodes to infinity (double.MaxValue, int.MaxValue), set distance of start node to 0

## Algorithm
1. select the node with the smallest distance that is unvisited (currNode)
2. if this node is the end node --> finished, found
3. if no unvisited nodes --> finished, no connection found
3. look at neigbouring nodes
    * if currNode.distance + edgeDistance (vector distance or actual edge distance) is smaller than neigborNode.distance
        * Set Prev of neighborNode to currNode and distance to currNode.distance + edgeDistance
    * else skip
4. after looking at neighbors, mark currNode as visited
5. goto 1

## Create the path
path: List
currNode: endnode
### while currNode is not null
1. add currNode to list at index 0
2. currNode = currNode.Prev
