//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;

public class RoomAdder:ProcessObject
{
	private int[,] grid;
	private int[] center;
	private int[] neighbors;
	private int[] rooms;
	private int neighborsCount = 0;
	private int roomCount = 1;

	public RoomAdder (int firstX, int firstY, int[,] grid, int numOfRooms)
	{
		this.grid = grid;
		center = new int[2];
		neighbors = new int[8];
		rooms = new int[numOfRooms*2];
		rooms[0] = firstX;
		rooms[1] = firstY;
	}

	public void AddCenter(int x, int y){
		center[0]=x;
		center[1]=y;
	}

	public void AddNeighbor(int x, int y){
		if(grid[x,y] == 0){
			int start = neighborsCount *2;
			neighbors[start] = x;
			neighbors[start +1] = y;
			neighborsCount++;
		}
	}

	public void Clear(){

	}

	public static int[] PickRoom(int numOfRooms, int[] listOfRooms){
		int start = (int)(UnityEngine.Random.value * numOfRooms) *2;
		int[] room = {listOfRooms[start],listOfRooms[start+1]};
		return room;
	}

	public void Process(){
		if(neighborsCount !=0){
			int[] newRoom = PickRoom(neighborsCount, neighbors);
			grid[newRoom[0],newRoom[1]] = 1;
			int start = roomCount * 2;
			rooms[start] = newRoom[0];
			rooms[start+1] = newRoom[1];
			roomCount++;
			neighborsCount=0;
		}
		
	}

	public int[] RoomList{
		get {return rooms;}
		set {rooms = value;}
	}

	public int RoomCount{
		get {return roomCount;}
		set {roomCount = value;}
	}


}


