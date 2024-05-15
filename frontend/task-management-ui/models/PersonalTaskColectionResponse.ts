import PersonalTask from "@/core/PersonalTask";

export default class PersonalTaskColectionResponse {
    #data: PersonalTask[] = []
    constructor() { }

    get data() {
        return this.#data
    }
}