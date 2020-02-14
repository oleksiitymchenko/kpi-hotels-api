declare module server {
	interface order {
		id: any;
		arrivalDate: Date;
		departureDate: Date;
		total: number;
		roomId: any;
		room: {
			id: any;
			serviceClassId: any;
			serviceClass: {
				id: any;
				roomKind: any;
				roomPrice: number;
			};
			floor: number;
			roomNumber: number;
			fridgeIncluded: boolean;
		};
		clientId: any;
		client: server.client;
	}
}
