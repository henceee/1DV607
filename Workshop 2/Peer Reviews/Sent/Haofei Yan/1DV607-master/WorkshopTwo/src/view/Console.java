package view;

import java.util.Scanner;

public class Console{
	
	public enum Event{
		
		None,
		Addmember,
		Addboat,
		CompactList,
		VerboseList,
		DeleteMember,
		ChangeMemberInformation,
		LookSpecificMemberInformation,
		DeleteBoat,
		ChangeBoatInformation,
		Input,
		Output
		
		
	}
	
	
	public void PresentInstructions(){
		
		System.out.println();
		
		
		System.out.println("Welcome to The happy pirate");
		System.out.println("Please type in what you want to do");
		System.out.println("Here are some options: Addmember, Addboat, CompactList, VerboseList, DeleteMember, ChangeMemberInformation, LookSpecificMemberInformation, DeleteBoat, ChangeBoatInformation, Input, Output");
		
	}
	
	
	
	public Event getEvent(){
		
		Scanner input=new Scanner(System.in);
		
		String str= input.nextLine();
		
		if(str.equals("Addmember")){
			
			return Event.Addmember;
		}
		if(str.equals("Addboat")){
			
			return Event.Addboat;
			
		}
		if(str.equals("CompactList")){
			
			return Event.CompactList;
		}
		if(str.equals("VerboseList")){
			
			return Event.VerboseList;
		}
		if(str.equals("DeleteMember")){
			
			return Event.DeleteMember;
		}
		if(str.equals("ChangeMemberInformation")){
			
			return Event.ChangeMemberInformation;
			
		}
		if(str.equals("LookSpecificMemberInformation")){
			
			return Event.LookSpecificMemberInformation;
			
		}
		if(str.equals("DeleteBoat")){
			
			
			return Event.DeleteBoat;
			
		}
		if(str.equals("ChangeBoatInformation")){
			
			return Event.ChangeBoatInformation;
		}
		if(str.equals("Input")){
			
			return Event.Input;
		}
		if(str.equals("Output")){
			
			return Event.Output;
		}
		
		return Event.None;
		
	}
	
	
	
	
	
	
	
	
	
	
	
	

}
