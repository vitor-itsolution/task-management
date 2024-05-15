import PersonalTaskColectionResponse from "@/models/PersonalTaskColectionResponse";
import PersonalTask from "../PersonalTask";

export default interface IPersonalTaskService {
    save(personalTask: PersonalTask): Promise<PersonalTask>
    updateState(id: string, state: number): Promise<PersonalTask>
    delete(personalTask: PersonalTask): Promise<any>
    getAll(): Promise<PersonalTaskColectionResponse>
}   