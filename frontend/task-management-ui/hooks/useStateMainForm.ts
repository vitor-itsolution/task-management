import { useState } from "react"

export default function useStateMainForm() {

    const [mainForm, setMainForm] = useState<'list' | 'form'>('list')
    const showForm = () => setMainForm('form');
    const showlist = () => setMainForm('list');

    return {
        visibleForm: mainForm === 'form',
        visibleList: mainForm === 'list',
        showForm,
        showlist
    }
}