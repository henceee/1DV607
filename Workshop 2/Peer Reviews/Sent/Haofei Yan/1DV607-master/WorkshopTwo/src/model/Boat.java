package model;

import java.util.UUID;

public class Boat {
	
	private UUID id;
	private String type;
	private int length;
	
	public Boat(){
		
		id=UUID.randomUUID();
	}
	
    public void setId(UUID id){
		
		this.id=id;
	}

	public UUID getId() {
		return id;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public int getLength() {
		return length;
	}

	public void setLength(int length) {
		this.length = length;
	}
	

}
