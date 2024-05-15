import { start } from "repl"

export default class PersonalTask {
    #id?: string
    #title: string
    #description: string
    #state: number
    #startDay: Date
    #endDay?: Date

    constructor(title: string, description: string, state: number, startDay: Date, endDay?: Date | undefined, id?: string | undefined) {
        this.#id = id
        this.#title = title
        this.#description = description
        this.#state = state
        this.#startDay = startDay
        this.#endDay = endDay
    }

    get id() {
        return this.#id;
    }

    static empty(){
        return new PersonalTask('', '', 1, new Date())
    }

    get title() {
        return this.#title;
    }

    get description() {
        return this.#description;
    }

    get state() {
        return this.#state;
    }

    get startDay() {
        return this.#startDay;
    }

    get endDay() {
        return this.#endDay;
    }
}