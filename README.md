<a name="readme-top"></a>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
	<li>
	  <a href="#about-the-project">About The Project</a>
	  <ul>
		<li><a href="#built-with">Built With</a></li>
	  </ul>
	</li>
	<li>
	  <a href="#getting-started">Getting Started</a>
	  <ul>
		<li><a href="#prerequisites">Prerequisites</a></li>
		<li><a href="#installation">Installation</a></li>
	  </ul>
	</li>
	<li><a href="#usage">Usage</a></li>
	<li><a href="#license">License</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Quadtree RPG

[Quadtree RPG](./readme-assets/Game-Screenshot.png)

Building off a Godot official RPG Demo, I used a quadtree data structure to implement a simple search and reveal positional system. This takes the form of a yellow slime you control, that as you move him forward, utilizes this quadtree to search the immediate area to find enemy slimes and reveals them.

The goal of this was to do a from scratch implmentation of an effecient way to locate objects via organizing and storing them by their positions.

### What is a Quadtree
You can think about a quadtree visually, which goes well with my usecase for a quadtree using positional data. 
A quadtree can be a representation of space divided into 4 rectangles or quadrants, each of those quadrants can cotain 4 children or contain another reactangle with 4 quadrants itself. This is an effecient way to store the spatial position of data, based on what quadrant they are in.

For example, we have a bunch of positional points and we want to query if some point _p_ is range. We _could_ compare every point in space to _p_, the brute force method that would take a long time.
Or we could use the quadtree, which find the correct quadrant using time effecient recursive methods, by finding each of the ancestor quadrants until the correct quadrant is found and the children can check if the point is a child of the quadrant (found) or deemed not in range. 


Why use a quadtree:
* A quadtree can take in spatial positioning data and offers good performance for insertion, removal and lookup. 
* In a game, spatial data is constantly changing, you need fast performing structures to handle the retreival and processes of this data.
* Tha alternative would be a brute force approach of checking all intersections.
* Great for sparse data sets. 

See more about quadtrees and spatial partitioning here:

[Quadtrees](https://en.wikipedia.org/wiki/Quadtree)

[Spatial Partition - Game Programming Patterns](https://gameprogrammingpatterns.com/spatial-partition.html)

Please refer to QT.cs and PlayerQT.cs for my personal code.

### Visual Walkthrough
[![Walkthrough](https://img.youtube.com/vi/d_pKo_JX2Hc/0.jpg)(https://youtu.be/d_pKo_JX2Hc)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With

* [Godot](https://godotengine.org/)
* C#

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

This project was written with Godot Engine .NET v4.2.2 in compatibility mode.

### Prerequisites

[.NET SDK](https://dotnet.microsoft.com/en-us/download) 

### Installation

Import project via Godot
Build via Godot .NET builder

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

Use Godot editor play button.
Use WASD to move.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>
