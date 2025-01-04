import React, { useEffect, useState } from "react";
import { getEvents } from "../../constant/fetchData";
import { Event } from "../../types/Event";

const EventList: React.FC = () => {
  const [events, setEvents] = useState<Event[]>([]);

  useEffect(() => {
    const fetchEvents = async () => {
      try {
        const data = await getEvents();
        setEvents(data);
      } catch (error) {
        console.error("Error fetching events:", error);
      }
    };

    fetchEvents();
  }, []);

  return (
    <div>
      <h2>Event List</h2>
      <ul>
        {events.map((event) => (
          <li key={event.eventId}>
            <h3>{event.title}</h3>
            <p>{event.description}</p>
            <p>
              {event.startDate} - {event.endDate}
            </p>
            <p>Location: {event.location}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default EventList;
