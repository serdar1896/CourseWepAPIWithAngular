import { Subscribe } from './Subscribe';

export class Course {
  Id: number;
  Title: string;
  Slug: string;
  Description: string;
  VideoUrl: string;
  Subscribe: Subscribe[]
}
