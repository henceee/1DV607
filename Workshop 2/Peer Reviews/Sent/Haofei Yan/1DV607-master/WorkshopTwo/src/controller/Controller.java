package controller;

import view.Console.Event;

public class Controller {
	
	public boolean Dothings(view.Console a_view, model.Server a_sys){
		
		a_view.PresentInstructions();
		
		view.Console.Event e;
		
		e = a_view.getEvent();
		
		if(e == Event.None){
			return false;
		}
		
		if(e == Event.Addmember){
			
			a_sys.Addmember();
			
		}
		if(e == Event.Addboat){
			
			a_sys.Addboat();
			
		}
		if(e == Event.CompactList){
			
			a_sys.CompactList();
			
		}
		if(e == Event.VerboseList){
			
			a_sys.VerboseList();
			
		}
		if(e == Event.DeleteMember){
			
			a_sys.DeleteMember();
			
		}
		if(e == Event.ChangeMemberInformation){
			
			a_sys.ChangeMemberInformation();
			
		}
		if(e == Event.LookSpecificMemberInformation){
			
			a_sys.LookSpecificMemberInformation();
			
		}
		if(e == Event.DeleteBoat){
			
			a_sys.DeleteBoat();
			
		}
		if(e == Event.ChangeBoatInformation){
			
			a_sys.ChangeBoatInformation();
			
		}
		if(e == Event.Input){
			
			a_sys.Input();
			
		}
		if(e == Event.Output){
			
			a_sys.Output();
			
		}
		
		
		
		
		return true;
	}
	
	

	
	

}
