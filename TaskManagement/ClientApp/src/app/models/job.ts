export class Job {
  constructor(
    public id?: number,
    public name?: string,
    public description?: string,
    public createdDate?: Date,
    public scheduledTime?: Date) { }
}
