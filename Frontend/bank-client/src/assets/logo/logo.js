import React from 'react'
import './logo.scss'

function Logo(props) {
	const hasAnotherSize = props.size ? ' ' + props.size : ''
	return (
		<div className={`logo${props.className ? ' ' + props.className : ''}`}>
			<span className={`noir${hasAnotherSize}`}>Noir</span>
			<span className={`bank${hasAnotherSize}`}>Bank</span>
		</div>
	)
}

export default Logo