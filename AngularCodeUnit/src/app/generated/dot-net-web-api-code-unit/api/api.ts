export * from './commonRoutes.service';
import { CommonRoutesService } from './commonRoutes.service';
export * from './customer.service';
import { CustomerService } from './customer.service';
export * from './example.service';
import { ExampleService } from './example.service';
export * from './maintenanceRoutes.service';
import { MaintenanceRoutesService } from './maintenanceRoutes.service';
export const APIS = [CommonRoutesService, CustomerService, ExampleService, MaintenanceRoutesService];
