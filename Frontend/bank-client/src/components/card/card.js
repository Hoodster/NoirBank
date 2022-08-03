import './card.scss'
function Card(props) {
    const cardNumberPrepared = `${props.cardNo.substring(0, 4)} **** **** ${props.cardNo.substring(12, 16)}`
    return <div className={`nb-card ${props.cardStyle}`}>
        <span>{cardNumberPrepared}</span>
        <div className='nb-card-row-last'>
        <span>{props.expiration}</span>
        <span className='nb-cardType'>{props.type}</span>
        </div>
        <span> </span>
    </div>
}

export default Card