interface ButtonProps {
    colorName?: 'green' | 'blue' | 'gray'
    className?: string
    children: any
    onClick?: () => void
}

export default function ButtonComponent(props: ButtonProps) {
    const _color = props.colorName ?? 'gray'
    return (
        <button onClick={props.onClick} className={`
            bg-gradient-to-r from-${_color}-400 to-${_color}-700
            text-white px-4 py-2 rounded-md
            ${props.className}
        `}>
            {props.children}
        </button>
    )
}