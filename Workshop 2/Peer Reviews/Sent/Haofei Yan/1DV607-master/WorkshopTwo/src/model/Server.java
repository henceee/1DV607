package model;

import java.util.ArrayList;
import java.util.Scanner;
import java.util.UUID;
import java.io.*;

public class Server {
	
	private Boat m_boat;
	private Member m_member;
	
	
	private ArrayList<Member> list;
	
	public Server(){
		
		list=new ArrayList<Member>();
		
	}
	
	public ArrayList<Member> getmembers(){
		
		return list;
	}
	
	public void Addmember(){
		
		m_member = new Member();
		
		Scanner input=new Scanner(System.in);
		
		System.out.println("Please type in New member's name: ");
        
		String str= input.nextLine();
		
		m_member.setName(str);
		
		System.out.println("Please type in New member's personalnumber: ");
		
		double tmp= input.nextDouble();
		
		m_member.setPersonalnumber(tmp);
		
		list.add(m_member);
		
	}
	
	public void Addboat(){
		m_boat = new Boat();
		
		Scanner input=new Scanner(System.in);
		
		System.out.println("Please type in the member'personalnumber first: ");
		
		double tmp=input.nextDouble();
		
		Member choose = new Member();
		int position = 0;
		boolean boo=false;
		
		for(int i=0;i<list.size();i++){
			
			if(list.get(i).getPersonalnumber()==tmp)
			{
				choose=list.get(i);
				position=i;
				boo=true;
				break;
			}
			
			
		}
		
		Scanner input2=new Scanner(System.in);
		
		System.out.println("Please type in this boat's type: Sailboat, Motorsailer, kayak/Canoe or Other: ");

		String str= input2.nextLine();
		
		m_boat.setType(str);
		
		System.out.println("Please type in this boat's length(meter): ");
		
	    int length= input2.nextInt();
	    
	    m_boat.setLength(length);
	   
	    choose.boats.add(m_boat);
		
	    if(boo==true){
	    	list.set(position, choose);
	    }
		
	}
	
	
	public void CompactList(){
		
		for(int i=0;i<list.size();i++)
		{
			System.out.println(list.get(i).getName()+" "+list.get(i).getId()+" "+list.get(i).boats.size()+" "+"boats");
			
		}
		
		
	}
	
	public void VerboseList(){
		
		for(int i=0;i<list.size();i++)
		{
			System.out.println(list.get(i).getName()+" "+list.get(i).getPersonalnumber()+" "+list.get(i).getId());
			System.out.println("Boats:");
			for(int j=0;j<list.get(i).boats.size();j++)
			{
				System.out.println(list.get(i).boats.get(j).getType()+" "+list.get(i).boats.get(j).getLength()+"m");
			}
			
		}
		
	}
	
	public void DeleteMember(){
		
		Scanner input=new Scanner(System.in);
		
		System.out.println("Please type in the member'personalnumber: ");
		
		double tmp=input.nextDouble();
		
		for(int i=0;i<list.size();i++){
			
			if(list.get(i).getPersonalnumber()==tmp)
			{
				list.remove(i);
				break;
			}
			
			
		}
		
		
	}
	
	public void ChangeMemberInformation(){
		
		Scanner input=new Scanner(System.in);
		
		System.out.println("Please type in the member'personalnumber: ");
		
		double tmp=input.nextDouble();
		
		Member choose = new Member();
		int position = 0;
		boolean boo=false;
		
		for(int i=0;i<list.size();i++){
			
			if(list.get(i).getPersonalnumber()==tmp)
			{
				choose=list.get(i);
				position=i;
				boo=true;
				break;
			}
			
			
		}
		
		Scanner input2=new Scanner(System.in);
		
		System.out.println("Please type in New member's name: ");

		String str= input2.nextLine();
		
		choose.setName(str);
		
		System.out.println("Please type in New member's personalnumber: ");
		
		int tmp2= input2.nextInt();
		
		choose.setPersonalnumber(tmp2);
		
		if(boo==true){
	    	list.set(position, choose);
	    }
		
	}
	
	public void LookSpecificMemberInformation(){
		
		Scanner input=new Scanner(System.in);
		
		System.out.println("Please type in the member'personalnumber: ");
		
		double tmp=input.nextDouble();
		
		Member choose = new Member();
		
		for(int i=0;i<list.size();i++){
			
			if(list.get(i).getPersonalnumber()==tmp)
			{
				choose=list.get(i);
				break;
			}
			
		}
		 System.out.println(choose.getName()+" "+choose.getPersonalnumber()+" "+choose.getId());
		 System.out.println("Boats:");
		 
		 for(int i=0;i<choose.boats.size();i++)
		 {
			 System.out.println(choose.boats.get(i).getType()+" "+choose.boats.get(i).getLength()+"m");
		 }
		 
	}
	
	public void DeleteBoat(){
		
		Scanner input=new Scanner(System.in);
		
		System.out.println("Please type in the member'personalnumber first: ");
		
		double tmp=input.nextDouble();
		
		Member choose = new Member();
		int position = 0;
		boolean boo=false;
		
		for(int i=0;i<list.size();i++){
			
			if(list.get(i).getPersonalnumber()==tmp)
			{
				choose=list.get(i);
				position=i;
				boo=true;
				break;
			}
			
		}
		System.out.println(choose.getName()+" "+choose.getPersonalnumber()+" "+choose.getId());
		System.out.println("Boats:");
		 
		 for(int i=0;i<choose.boats.size();i++)
		 {
			 System.out.println(choose.boats.get(i).getType()+" "+choose.boats.get(i).getLength()+"m");
		 }
		 
		 System.out.print("Please type in which boat you want to delete (please type in the number): ");
		 
		 int ship=input.nextInt()-1;
		 choose.boats.remove(ship);
		 
		 if(boo==true){
		    	list.set(position, choose);
		 }
		
	}
	
	public void ChangeBoatInformation(){
		
		Scanner input=new Scanner(System.in);
		
		System.out.println("Please type in the member'personalnumber first: ");
		
		double tmp=input.nextDouble();
		
		Member choose = new Member();
		int position = 0;
		boolean boo=false;
		
		for(int i=0;i<list.size();i++){
			
			if(list.get(i).getPersonalnumber()==tmp)
			{
				choose=list.get(i);
				position=i;
				boo=true;
				break;
			}
			
		}
		System.out.println(choose.getName()+" "+choose.getPersonalnumber()+" "+choose.getId());
		System.out.println("Boats:");
		 
		 for(int i=0;i<choose.boats.size();i++)
		 {
			 System.out.println(choose.boats.get(i).getType()+" "+choose.boats.get(i).getLength()+"m");
		 }
		 
		 
		 System.out.print("Please type in which boat's information you want to change (please type in the number): ");
		 
		 int ship=input.nextInt()-1;
		 
		 Boat change=choose.boats.get(ship);
		 
		 Scanner input2=new Scanner(System.in);
		 
		 System.out.println("Please type in this boat's type: Sailboat, Motorsailer, kayak/Canoe or Other");

			String str= input2.nextLine();
			
			change.setType(str);
			
			System.out.print("Please type in this boat's length(meter): ");
			
		    int length= input2.nextInt();
		    
		    change.setLength(length);
		 
		 choose.boats.set(ship, change);
		 
		 if(boo==true){
		    	list.set(position, choose);
		 }
		 
	}
	
	public void Output(){
		
		try{
		PrintWriter writer=new PrintWriter("data.txt","UTF-8");
		
		StringBuilder print = new StringBuilder();
		for(int i=0;i<list.size();i++)
		{
			print.append(list.get(i).getName()+" "+list.get(i).getPersonalnumber()+" "+list.get(i).getId());
			print.append("\n");
			print.append("Boats:");
			print.append("\n");
			for(int j=0;j<list.get(i).boats.size();j++)
			{
				print.append(list.get(i).boats.get(j).getType()+" "+list.get(i).boats.get(j).getLength()+"m");
			    print.append("\n");
			}
			
		}
		
		writer.println(print);
		writer.close();
		}catch(IOException e){
			
			e.printStackTrace();
			
		}
		
	}
	public void Input(){
		
		 try{
			 
			 StringBuilder text=new StringBuilder();
				
				Scanner scan=new Scanner(new File("/Users/CaptainYan/Documents/workspace/WorkshopTwo/data.txt"));
				
				while(scan.hasNext())
				{
					text.append(scan.nextLine()+"\n");
					
				}
			    
			    System.out.println(text);
			 
		 }catch (Exception e) {
			 e.printStackTrace(); 
		 }
		 
		 String name;
		 int id;
		 UUID uid;
		 
		 
		 
	}
	
	
	

}
