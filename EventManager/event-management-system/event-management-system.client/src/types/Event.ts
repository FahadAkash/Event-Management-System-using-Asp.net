export interface Attendee {
    attendeeId: number;
    name: string;
    email: string;
    eventId: number;
  }
  
  export interface Event {
    eventId: number;
    title: string;
    description: string;
    startDate: string;
    endDate: string;
    location: string;
    attendees: Attendee[];
  }
  
  export interface CreateEventDto {
    title: string;
    description: string;
    startDate: string;
    endDate: string;
    location: string;
    attendees: Attendee[];
  }
  