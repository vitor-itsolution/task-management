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
        personalTaskService.getAll().then((personalTasks) => {
            setPersonalTasks(personalTasks)
            showlist()
        })
    }

    function onSelected(personalTask: PersonalTask) {
        setPersonalTask(personalTask)
        showForm()
    }
    async function onDeleted(personalTask: PersonalTask) {
        await personalTaskService.delete(personalTask)
        getAll();
    }

    async function onSave(personalTask: PersonalTask) {
        await personalTaskService.create(personalTask)
        getAll()
    }

    function onCreateNewTask() {
        debugger
        setPersonalTask(PersonalTask.empty())
        showForm()
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
        onSave
    }
}