import { serviceClass } from './service-class';

export	interface room {
    id: any;
    serviceClassId: any;
    serviceClass: serviceClass;
    floor: number;
    roomNumber: number;
    fridgeIncluded: boolean;
}
