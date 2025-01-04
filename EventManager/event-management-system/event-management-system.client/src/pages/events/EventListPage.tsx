import React from "react";
import EventList from "../../components/events/EventList";

const EventListPage: React.FC = () => {
  return (
    <div>
      <h1>Event Management</h1>
      <EventList />
    </div>
  );
};

export default EventListPage;
