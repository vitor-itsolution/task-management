import TitleComponent from "./TitleComponent"

interface LayoutProps {
    title: string,
    children: any
}

export default function LayoutComponent(props: LayoutProps) {
    return (
        <div className={`
        flex flex-col w-2/3
        bg-white text-gray-800 rounded-md
        `}>
            <TitleComponent>{props.title}</TitleComponent>
            <div className={`p-6`}>
                {props.children}
            </div>
        </div>
    )
}