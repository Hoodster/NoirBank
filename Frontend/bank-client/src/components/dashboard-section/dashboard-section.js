import React from 'react'
import './dashboard-section.scss'

function DashboardSection(props) {
	return (
		<div className='nb-dash-section'>
			<div className='titleSection'>
				<span className="title">{props.title}</span>
				{props.option ? props.option : null}
			</div>
			<div className={`container
			${!props.children ? ' container-empty' : ''}
			${props.height ? props.height : ''}`}>
				{props.children
					? props.children
					: <span style={{ 'margin': '65px 0' }} className='emptyMessage'>{props.emptyChildrenText}</span>}
			</div>
		</div>
	)
}

export default DashboardSection