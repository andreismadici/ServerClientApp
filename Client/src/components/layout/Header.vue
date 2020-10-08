<template>
    <header class="header">
        <h1>Comanda</h1>
        <button @click="$emit('trimite-comanda')" class="btn">Trimite Comanda</button>
    </header>
</template>

<script>
export default {
    name: "Header"
   

}
</script>

<style scoped>
    .header {
        background: #333;
        color: #fff;
        text-align: center;
        padding: 10px;
    }

    .header a {
        color: #fff;
        padding-right: 5px;
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
