import PersonalTask from "@/core/PersonalTask";
import { DeleteIcon, EditIcon, SuccessIcon } from "./IconComponent";

interface TableProps {
    personalTasks: PersonalTask[]
    onSelected?: (personalTask: PersonalTask) => void
    onDeleted?: (personalTask: PersonalTask) => void
    onFinished?: (personalTask: PersonalTask) => void
}
export default function TableComponent(props: TableProps) {


    const showActions = props.onDeleted || props.onSelected

    function renderHeader() {
        return (
            <tr>
                <th className="text-left p-4">Title</th>
                <th className="text-left p-4">Description</th>
                <th className="text-left p-4">StartDay</th>
                {showActions ? <th className="p-4">Actions</th> : false}
            </tr>
        )
    }

    function renderBody() {
        return props.personalTasks?.map((personalTask, i) => {
            const cssFinished = personalTask.state === 3 ? 'line-through' : ''
            const shortDate = personalTask.startDay.toString().slice(0, 10)
            return (
                <tr key={personalTask.id}
                    className={`${cssFinished} ${i % 2 === 0 ? 'bg-purple-200' : 'bg-purple-100'}`}>
                    <td className="text-left p-4">{personalTask.title}</td>
                    <td className="text-left p-4">{personalTask.description}</td>
                    <td className="text-left p-4">{shortDate}</td>
                    {showActions ? renderActions(personalTask) : false}
                </tr>
            )
        })
    }

    function renderActions(personalTask: PersonalTask) {
        return (
            <td className="flex justify-center">
                {props.onSelected ? (
                    <button onClick={() => props.onSelected?.(personalTask)}
                        disabled={personalTask.state === 3}
                        className={`
                          flex justify-center items-center
                          text-blue-600 rounded-full p-2 m-1
                          ${personalTask.state === 3 ? '' : 'hover:bg-purple-50'}
                      `}>{EditIcon}</button>
                ) : false}
                {props.onDeleted ? (
                    <button onClick={() => props.onDeleted?.(personalTask)}
                        disabled={personalTask.state === 3}
                        className={`
                        flex justify-center items-center
                        text-red-500 rounded-full p-2 m-1
                         ${personalTask.state === 3 ? '' : 'hover:bg-purple-50'}
                    `}>{DeleteIcon}</button>
                ) : false}
                {props.onFinished ? (
                    <button onClick={() => props.onFinished?.(personalTask)}
                        disabled={personalTask.state === 3}
                        className={`
                              flex justify-center items-center
                              text-green-600 rounded-full p-2 m-1
                              ${personalTask.state === 3 ? '' : 'hover:bg-purple-50'}
                          `}>{SuccessIcon}</button>
                ) : false}

            </td>
        )
    }

    return (
        <table className={`
            w-full rounded-xl overflow-hidden
        `}>
            <thead className={`
                text-gray-100   
                bg-gradient-to-r from-purple-500 to-purple-800

            `}>
                {renderHeader()}
            </thead>
            <tbody>
                {renderBody()}
            </tbody>
        </table>
    )
}