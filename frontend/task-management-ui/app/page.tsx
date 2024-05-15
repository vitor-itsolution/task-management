"use client"
import LayoutComponent from "../components/LayoutComponent";
import TableComponent from "../components/TableComponent";
import ButtonComponent from "../components/ButtonComponent";
import FormComponent from "../components/FormComponent";
import usePersonalTask from "@/hooks/usePersonalTask";

export default function Home() {

  const { 
    visibleList,
    personalTask, 
    personalTasks, 
    onCreateNewTask, 
    onDeleted, 
    onSelected, 
    showlist,
    onSave, 
    onFinished
  } = usePersonalTask()

  return (
    <main className={`
      flex justify-center items-center h-screen
      bg-gradient-to-r from-blue-500 to-purple-500
    `}>
      <LayoutComponent title="Task lisk">
        {visibleList ? (
          <>
            <div className="flex justify-end">
              <ButtonComponent colorName="green" className="mb-4"
                onClick={onCreateNewTask}
              >
                New Task
              </ButtonComponent>
            </div>
            <TableComponent
              personalTasks={personalTasks}
              onDeleted={onDeleted}
              onSelected={onSelected}
              onFinished={onFinished}>
            </TableComponent>
          </>
        ) : (
          <FormComponent
            personalTask={personalTask}
            onCanceled={() => showlist()}
            onPersonalTaskChanged={onSave}
          />
        )}
      </LayoutComponent>
    </main>
  );
}
