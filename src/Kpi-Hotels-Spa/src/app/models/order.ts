import { client } from './Client';
import { room } from './room';

export	interface order {
	id: any;
	arrivalDate: Date;
	departureDate: Date;
	total: number;
	roomId: any;
	room: room;
	floor: number;
	roomNumber: number;
	fridgeIncluded: boolean;
	clientId: any;
	client: client;
}
