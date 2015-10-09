package model;

import java.util.ArrayList;
import java.util.UUID;

public class Member implements Comparable<Member>{
	
    private UUID id;
	private String name;
	private double personalnumber;
	ArrayList<Boat> boats=new ArrayList<Boat>();
	
	public Member(){
		id=UUID.randomUUID();
	}
	

	public UUID getId() {
		return id;
	}
	
	public void setId(UUID id){
		
		this.id=id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public double getPersonalnumber() {
		return personalnumber;
	}

	public void setPersonalnumber(double personalnumber) {
		this.personalnumber = personalnumber;
	}

	public ArrayList<Boat> getboats(){
		
		return boats;
		
	}


	@Override
	public int compareTo(Member o) {
		
		return Double.compare(this.getPersonalnumber(), o.getPersonalnumber());
	}

}
