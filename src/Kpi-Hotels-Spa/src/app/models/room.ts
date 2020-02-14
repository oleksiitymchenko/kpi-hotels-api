declare module server {
	interface room {
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
	}
}
