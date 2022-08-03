import React from 'react'
import './button.scss'

function Button(props) {
	return <button className={`nb-button ${props.type} ${props.style}`}>
		{props.icon ? <span className="nb-ico">{props.icon}</span> : null}
		<span>{props.text}</span>
	</button>
}

export default Button