import axios from "axios";
import PersonalTask from "../PersonalTask";
import IPersonalTaskService from "../interfaces/IPersonalTaskService";
import PersonalTaskColectionResponse from "@/models/PersonalTaskColectionResponse";

export const axiosInstance = axios.create({
    baseURL: process.env.NEXT_PUBLIC_BASE_ADDRESS_API
})

export default class PersonalTaskService implements IPersonalTaskService {
    
    updateState(id: string | undefined, state: number): Promise<PersonalTask> {
        return axiosInstance.patch(`task/${id}/state`, {
            State: state
        })
    }

    save(personalTask: PersonalTask): Promise<PersonalTask> {
        const startDay = new Date(personalTask.startDay)
        var request = {
            Title: `${personalTask.title}`,
            Description: `${personalTask.description}`,
            State: 1,
            StartDay: `${startDay.toISOString().replace(/\.\d{3}Z$/, '')}`
        }
        if (personalTask?.id)
            return axiosInstance.put(`task/${personalTask.id}`, request)
        else
            return axiosInstance.post('task', request)
    }

    delete(personalTask: PersonalTask): Promise<any> {
        return axiosInstance.delete(`task/${personalTask.id}`)
    }

    getAll(): Promise<PersonalTaskColectionResponse> {
        return axiosInstance.get('/task')
    }

}