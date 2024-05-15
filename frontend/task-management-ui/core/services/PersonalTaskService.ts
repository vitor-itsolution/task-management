import PersonalTask from "../PersonalTask";
import IPersonalTaskService from "../interfaces/IPersonalTaskService";

export default class PersonalTaskService implements IPersonalTaskService{
    async create(personalTask: PersonalTask): Promise<PersonalTask> {
        return PersonalTask.empty()
    }
    async update(personalTask: PersonalTask): Promise<PersonalTask> {
        return PersonalTask.empty()
    }
    async delete(personalTask: PersonalTask): Promise<void> {
        
    }
    async getAll(): Promise<PersonalTask[]> {
        return []
    }

}