import React , { useState } from 'react';
import { CreateEventDto } from '../types/Event';

const CreateEvent: React.FC = () => {
    const [ eventData , setEventData ] = useState<CreateEventDto>({

        title : "",
        description : "",
        startDate : "",
        endDate : "",
        location : "",
        attendees : []

    }); 
    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        
        const { name, value } = e.target;
        setEventData({
            ...eventData,
            [name]: value,
        });
    }
    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        try {
            const response = await CreateEvent(eventData);
            console.log(response);
        } catch (error) {
            console.error(error);
        }
    }
    return (
        <>
        <form action="" onSubmit={handleSubmit}>
            <h2>Create Event</h2>
            <input type="text" name="title" value={eventData.title} onChange={handleChange} placeholder="Title" />
            <textarea name="description" id="" placeholder='Description' onChange={handleChange}></textarea>
            <input type="text" name="startDate" value={eventData.startDate} onChange={handleChange} placeholder="Start Date" />
            <input type="text" name="endDate" value={eventData.endDate} onChange={handleChange} placeholder="End Date" />
            <input type="text" name="location" value={eventData.location} onChange={handleChange} placeholder="Location" />
            <button type="submit">Create Event</button>
        </form>
        </>
    )
}

export default CreateEvent; 
