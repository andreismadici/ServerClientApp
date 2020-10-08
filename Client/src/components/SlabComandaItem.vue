<template>
    <div class="slabComanda-item">
        <form>
            <p class = "mt">Material: {{SC.material}}</p>
            <p class = "mt">Lungime: {{SC.lungime}}</p>
            <p class = "mt">Latime: {{SC.latime}}</p>
            <button @click="$emit('del-slabComanda', SC.idSC)" class="del">X</button>
        </form>
    </div>
</template>

<script>
export default {
    name: "SlabComandaItem",
    props: ["SC"]
}
</script>

<style scoped>
    form {
        display: flex;
    }

    .mt {
        float: left;
        flex: 1;
        padding: 5px 9px;
    }

    .slabComanda-item{
        background: #f4f4f4;
        padding: 10px;
        border-bottom: 1px #ccc dotted;
    }

    .is-complete {
        text-decoration: line-through;
    }

    .del {
        background: #ff0000;
        color: #fff;
        border: none;
        padding: 5px 9px;
        border-radius: 50%;
        cursor: pointer;
        float: right;
    }

    .btn {
        display: inline-block;
        border: none;
        background: #555;
        color: #fff;
        padding: 7px 20px;
        cursor: pointer;
    }
    
</style>
