interface InputProps {
    type?: 'text' | 'number'
    label: string
    value: any
    readonly?: boolean
    className?: string
    onChange?: (value: any) => void
}

export default function InputComponent(props: InputProps) {
    return (
        <div className={`flex flex-col ${props.className}`}>
            <label className="mb-4">{props.label}</label>
            <input
                type={props.type ?? 'text'}
                value={props.value}
                readOnly={props.readonly}
                onChange={e=> props.onChange?.(e.target.value)}
                className={`
                    border border-purple-500 rounded-lg
                    focus:outline-none bg-gray-100 px-4 py-2
                    ${props.readonly ? '' : 'focus:bg-white'}
                `}
            />
        </div>
    )
}