import PersonalTask from "@/core/PersonalTask"
import InputComponent from "./InputComponent"
import { useState } from "react"
import ButtonComponent from "./ButtonComponent"

interface FormProps {
    personalTask: PersonalTask,
    onCanceled?: () => void
    onPersonalTaskChanged?: (personalTask: PersonalTask) => void
}

export default function FormComponent(props: FormProps) {
    const id = props.personalTask?.id
    const [title, setTitle] = useState(props.personalTask?.title ?? '')
    const [description, setTDescription] = useState(props.personalTask?.description ?? '')
    const [state, setState] = useState(props.personalTask?.state ?? '')
    const [startDay, setStartDay] = useState(props.personalTask?.startDay ?? '')
    const [endDay, setEndDay] = useState(props.personalTask?.endDay ?? undefined)
    return (
        <div>
            {id ? (
                <InputComponent className="mb-4" readonly label="Id" type="text" value={id} />
            ) : false}
            <InputComponent className="mb-4" label="Title" type="text" value={title} onChange={setTitle} />
            <InputComponent className="mb-4" label="Description" type="text" value={description} onChange={setTDescription} />
            <InputComponent className="mb-4" label="StartDay" type="text" value={startDay} onChange={setStartDay} />
            <InputComponent className="mb-4" label="EndDay" type="text" value={endDay} onChange={setEndDay} />
            <div className="flex justify-end mt-7">
                <ButtonComponent onClick={() => props.onPersonalTaskChanged?.(new PersonalTask(title, description, state, startDay, endDay, id))} className="mr-2" colorName="blue" >
                    {id ? 'Update' : 'Create'}
                </ButtonComponent>
                <ButtonComponent onClick={props.onCanceled} colorName="gray" >
                    Cancel
                </ButtonComponent>
            </div>
        </div>
    )
}