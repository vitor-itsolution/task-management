import PersonalTask from "../PersonalTask";

export default interface IPersonalTaskService {
    create(personalTask: PersonalTask): Promise<PersonalTask>
    update(personalTask: PersonalTask): Promise<PersonalTask>
    delete(personalTask: PersonalTask): Promise<void>
    getAll(): Promise<PersonalTask[]>
}