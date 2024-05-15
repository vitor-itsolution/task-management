import PersonalTask from "@/core/PersonalTask";
import PersonalTaskService from "@/core/services/PersonalTaskService";
import { useEffect, useState } from "react";
import useStateMainForm from "./useStateMainForm";

export default function usePersonalTask() {

    const { showForm, showlist, visibleForm, visibleList } = useStateMainForm()
    const [personalTask, setPersonalTask] = useState<PersonalTask>(PersonalTask.empty())
    const [personalTasks, setPersonalTasks] = useState<PersonalTask[]>([])
    const personalTaskService: PersonalTaskService = new PersonalTaskService();

    useEffect(getAll, [])

    function getAll() {
        personalTaskService.getAll().then((res) => {
            var personalTasks: PersonalTask[] = []
            res?.data?.map((p) => personalTasks.push(p))
            setPersonalTasks(personalTasks)
            showlist()
        })
    }

    function onSelected(personalTask: PersonalTask) {
        setPersonalTask(personalTask)
        showForm()
    }

    function onDeleted(personalTask: PersonalTask) {
        personalTaskService.delete(personalTask).then(() => {
            getAll();
        })
    }

    function onSave(personalTask: PersonalTask) {
        personalTaskService.save(personalTask).then(() => {
            getAll()
        })
    }

    function onCreateNewTask() {
        setPersonalTask(PersonalTask.empty())
        showForm()
    }

    function onFinished(personalTask: PersonalTask) {
        debugger
        personalTaskService.updateState(personalTask.id, 3).then(() => {
            getAll();
        })
    }

    return {
        visibleForm,
        visibleList,
        personalTasks,
        personalTask,
        onDeleted,
        showForm,
        showlist,
        onSelected,
        onCreateNewTask,
        onSave,
        onFinished
    }
}