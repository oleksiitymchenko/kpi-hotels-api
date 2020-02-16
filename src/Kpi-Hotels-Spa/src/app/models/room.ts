import { serviceClass } from './service-class';

export	class room {
    id: any;
    serviceClassId: any;
    serviceClass: serviceClass;
    floor: number;
    roomNumber: number;
    fridgeIncluded: boolean;
}
