import axios from "axios";  

import { Event } from "../types/Event";

const apiClient = axios.create({
    baseURL: "https://localhost:5062/api",
    headers: {
        "Content-type": "application/json"
    }
});

export const getEvents = async (): Promise<Event[]> => {
    try{
        const response = await apiClient.get<Event[]>("eventmangement");
        return response.data;
    }
    catch(error){
        return [];
    }
    
   
}

export const createEvent = async (event: Event): Promise<Event> => {
    const response = await apiClient.post<Event>("event", event);
    return response.data;
}

