import { Role, Subscribe } from "./";

export class User {
  Id: number;
  FirstName: string;
  LastName: string;
  Email: string;
  Password: string;
  RoleId: number;
  Token: string;
  Subscribe: Subscribe[]
}
